// Added: 2025/06/06, Juan Davel/ringwood-dsg.
// Based on MySQLRecordset.
// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com
// (c) 2025 Ringwood Digital Solutions Group (Pty) Ltd.
// https://www.ringwoodgroup.co.za
// Based on <MySQLRecordset>

#include "stdafx.h"

#include "MariaDBRecordset.h"
#include "MariaDBConnection.h"

#include "../Util/Unicode.h"
#include "../SQL/ColumnPositionCache.h"

#ifdef _DEBUG
#define DEBUG_NEW new(_NORMAL_BLOCK, __FILE__, __LINE__)
#define new DEBUG_NEW
#endif

namespace HM
{
   MariaDBRecordset::MariaDBRecordset() :
      result_(0),
      current_(0)
   {
      
   }

   MariaDBRecordset::~MariaDBRecordset()
   {
      try
      {
         Close_();
      }
      catch (...)
      {

      }
   }

   DALConnection::ExecutionResult
   MariaDBRecordset::TryOpen(std::shared_ptr<DALConnection> pDALConn, const SQLCommand &command, String &sErrorMessage)
   //---------------------------------------------------------------------------()
   // DESCRIPTION:
   // Opens a recordset specified by the given SQL string sSQL.
   //---------------------------------------------------------------------------()
   {  
      std::shared_ptr<MariaDBConnection> pConn = std::static_pointer_cast<MariaDBConnection>(pDALConn);

      String sSQL = command.GetQueryString();

      try
      {
         /*hm_MARIADB *pMYSQL = pConn->GetConnection();*/
         MYSQL* pMYSQL = pConn->GetConnection();

         AnsiString sQuery;
         if (!Unicode::WideToMultiByte(sSQL, sQuery))
         {
            ErrorManager::Instance()->ReportError(ErrorManager::Critical, 5108, "MariaDBRecordset::TryOpen", "Could not convert string into multi-byte.");
            return DALConnection::DALUnknown;
         }

         /*if (MariaDBInterface::Instance()->p_mariadb_query(pMYSQL, sQuery))*/
         if (mysql_query(pMYSQL, sQuery))
         {
            DALConnection::ExecutionResult result = pConn->CheckError(pMYSQL, sSQL, sErrorMessage);
            return result;
         }

         // Store the result of the query
         /*result_ = MariaDBInterface::Instance()->p_mariadb_store_result(pMYSQL);*/
         result_ = mysql_store_result(pMYSQL);

         // Move to the first row.
         MoveNext();

         // Cache positions so we don't have to pick them up later...
         column_positions_ = pConn->GetColumnPositionCache().GetPositions(sQuery, this);
      }
      catch (...)
      {
         ErrorManager::Instance()->ReportError(ErrorManager::High, 4202, "MariaDBRecordset::TryOpen", "An unknown error occurred while executing " + sSQL);
         return DALConnection::DALErrorInSQL;
      }

      return DALConnection::DALSuccess;

   }


   void
   MariaDBRecordset::Close_()
   //---------------------------------------------------------------------------()
   // DESCRIPTION:
   // Closes a recordset.
   //---------------------------------------------------------------------------()
   {
      try
      {
         if (result_)
         {
            /*MariaDBInterface::Instance()->p_mariadb_free_result(result_);*/
            mysql_free_result(result_);
            result_ = 0;
         }
      }
      catch (...)
      {
         ErrorManager::Instance()->ReportError(ErrorManager::Medium, 4203, "MariaDBRecordset::Close", "An unknown error occurred while closing recordset.");
      }
   }

   long
   MariaDBRecordset::RecordCount() const
   //---------------------------------------------------------------------------()
   // DESCRIPTION:
   // Returns the number of rows in current recordset. 
   //---------------------------------------------------------------------------()
   {
      if (!result_)
         return 0;
 
      try
      {
         /*long lResult = (long) MariaDBInterface::Instance()->p_mariadb_num_rows(result_);*/
         long lResult = (long)mysql_num_rows(result_);
         return lResult;
      }
      catch (...)
      {
         ErrorManager::Instance()->ReportError(ErrorManager::High, 4204, "MariaDBRecordset::RecordCount", "An unknown error occurred while determining number of rows in record set.");
         throw;
      }

   }

   bool
   MariaDBRecordset::IsEOF() const
   {
      return current_ == 0;
   }

   bool
   MariaDBRecordset::MoveNext()
   //---------------------------------------------------------------------------()
   // DESCRIPTION:
   // Moves the cursor to the next row in the recordset.
   //---------------------------------------------------------------------------()
   {
      if (!result_)
      {
         return false;
      }


      try
      {
         /*current_ = MariaDBInterface::Instance()->p_mariadb_fetch_row(result_);*/
         current_ = mysql_fetch_row(result_);
      }
      catch (...)
      {
         ErrorManager::Instance()->ReportError(ErrorManager::High, 4206, "MariaDBRecordset::MoveNext", "An unknown error occurred while reading the next row from an record set.");
         throw;
      }

      if (current_)
         return true;
      else
         return false;
   }

   int 
   MariaDBRecordset::GetColumnIndex_(const AnsiString &sColumnName) const
   //---------------------------------------------------------------------------()
   // DESCRIPTION:
   // Returns the index of a column in the recordset, based on the columns name.
   //---------------------------------------------------------------------------()
   {
      int index = column_positions_->GetColumnIndex(sColumnName);
      if (index >= 0)
         return index;

      ErrorManager::Instance()->ReportError(ErrorManager::High, 4231, "MariaDBRecordset::GetColumnIndex_", "The requested column was not found. Column name: " + sColumnName);
      return -1;
   }

   String
   MariaDBRecordset::GetStringValue(const AnsiString &FieldName) const
   //---------------------------------------------------------------------------()
   // DESCRIPTION:
   // Returns the value of a string in the current row in the recordset.
   //---------------------------------------------------------------------------()
   {
      if (IsEOF())
      {
         ReportEOFError_(FieldName);
         return "";
      }

      try
      {
         int iColIdx = GetColumnIndex_(FieldName);
         char *pValue = current_[iColIdx];
         
         if (pValue == 0 || strlen(pValue) == 0)
            return "";

         String sOutput;
         if (!Unicode::MultiByteToWide(pValue, sOutput))
         {
            ErrorManager::Instance()->ReportError(ErrorManager::Critical, 5109, "MariaDBRecordset::GetStringValue", "Could not convert multi byte to wide char.");
            return "";            
         }

         return sOutput;
      }
      catch (...)
      {
         ErrorManager::Instance()->ReportError(ErrorManager::High, 4207, "MariaDBRecordset::GetStringValue", "An unknown error occurred while reading value from recordset: " + FieldName);
         throw;
      }
   }


   long
   MariaDBRecordset::GetLongValue(const AnsiString &FieldName) const
   //---------------------------------------------------------------------------()
   // DESCRIPTION:
   // Returns the value of a long in the current row in the recordset.
   //---------------------------------------------------------------------------()
   {
      if (IsEOF())
      {
         ReportEOFError_(FieldName);
         return 0;
      }

      try
      {
         int iColIdx = GetColumnIndex_(FieldName);
         char *pValue = current_[iColIdx];
         long lVal = pValue ? atoi(pValue) : 0;
         return lVal;
      }
      catch (...)
      {
         ErrorManager::Instance()->ReportError(ErrorManager::High, 4207, "MariaDBRecordset::GetLongValue", "An unknown error occurred while reading value from recordset: " + FieldName);
         throw;
      }
   }

   bool 
   MariaDBRecordset::GetIsNull(const AnsiString &FieldName) const
   //---------------------------------------------------------------------------()
   // DESCRIPTION:
   // Returns true if the column contains NULL
   //---------------------------------------------------------------------------()
   {
      if (IsEOF())
      {
         ReportEOFError_(FieldName);
         return false;
      }

      try
      {
         int iColIdx = GetColumnIndex_(FieldName);
         char *pValue = current_[iColIdx];

         if (pValue == 0)
            return true;

         return false;
      }
      catch (...)
      {
         ErrorManager::Instance()->ReportError(ErrorManager::High, 5302, "MariaDBRecordset::GetIsNull", "An error occured while checking for null.");
         throw;
      }
   }

    __int64
   MariaDBRecordset::GetInt64Value(const AnsiString &FieldName) const
   //---------------------------------------------------------------------------()
   // DESCRIPTION:
   // Returns the value of a string in the current row in the recordset.
   //---------------------------------------------------------------------------()
   {
      if (IsEOF())
      {
         ReportEOFError_(FieldName);
         return 0;
      }

      try
      {
         int iColIdx = GetColumnIndex_(FieldName);
         char *pValue = current_[iColIdx];
         __int64 lVal = pValue ? _atoi64(pValue) : 0;
         return lVal;
      }
      catch (...)
      {
         ErrorManager::Instance()->ReportError(ErrorManager::High, 4207, "MariaDBRecordset::GetInt64Value", "An unknown error occurred while reading value from recordset: " + FieldName);
         throw;
      }
   }

   double
   MariaDBRecordset::GetDoubleValue(const AnsiString &FieldName) const
   //---------------------------------------------------------------------------()
   // DESCRIPTION:
   // Returns the value of a string in the current row in the recordset.
   //---------------------------------------------------------------------------()
   {
      if (IsEOF())
      {
         ReportEOFError_(FieldName);
         return 0;
      }

      try
      {
         int iColIdx = GetColumnIndex_(FieldName);
         char *pValue = current_[iColIdx];
         double dbVal = pValue ? atof(pValue) : 0;

         return dbVal;
      }
      catch (...)
      {
         ErrorManager::Instance()->ReportError(ErrorManager::High, 4207, "MariaDBRecordset::GetLongValue", "An unknown error occurred while reading value from recordset: " + FieldName);
         throw;
      }
   }

   std::vector<AnsiString> 
   MariaDBRecordset::GetColumnNames() const
   {
      std::vector<AnsiString> result;
      /*unsigned int iFieldCount = MariaDBInterface::Instance()->p_mariadb_num_fields(result_);*/
      unsigned int iFieldCount = mysql_num_fields(result_);

      for (unsigned int i = 0; i < iFieldCount; i++)
      {
         /*hm_st_mariadb_field *pField = MariaDBInterface::Instance()->p_mariadb_fetch_field_direct(result_, i);*/
         MYSQL_FIELD* pField = mysql_fetch_field_direct(result_, i);

         result.push_back(pField->name);
      }  
      return result;
   }
}
