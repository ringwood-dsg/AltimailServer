// (c) 2025 Ringwood Digital Solutions Group (Pty) Ltd.
// https://www.ringwoodgroup.co.za

#pragma once

#include "DALConnection.h"
//#include "MariaDBInterface.h"
#include <mysql.h>
#include "ColumnPositionCache.h"

namespace HM
{
   

   class MariaDBConnection : public DALConnection, public std::enable_shared_from_this<MariaDBConnection>
   {
   public:

      enum Server
      {
         RequiredVersion = 100529 //MariaDB 10.5.29GA or later
      };

	   MariaDBConnection(std::shared_ptr<DatabaseSettings> pSettings);
	   virtual ~MariaDBConnection();

      virtual ConnectionResult Connect(String &sErrorMessage);
      virtual bool Disconnect();
      virtual ExecutionResult TryExecute(const SQLCommand &command, String &sErrorMessage, __int64 *iInsertID = 0, int iIgnoreErrors = 0); 
      virtual bool IsConnected() const;

      //hm_MARIADB *GetConnection() const;
      MYSQL* GetConnection() const;

      //ExecutionResult CheckError(hm_MARIADB *pSQL, const String &sAdditionalInfo, String &sOutputErrorMessage) const;
      ExecutionResult CheckError(MYSQL* pSQL, const String& sAdditionalInfo, String& sOutputErrorMessage) const;

      virtual void OnConnected();

      virtual bool BeginTransaction(String &sErrorMessage);
      virtual bool CommitTransaction(String &sErrorMessage);
      virtual bool RollbackTransaction(String &sErrorMessage);
      virtual void SetTimeout(int seconds) {}

      virtual bool GetSupportsCommandParameters() const {return false; }
      ColumnPositionCache& GetColumnPositionCache() {return column_position_cache_;}

      virtual bool CheckServerVersion(String &errorMessage);

      virtual std::shared_ptr<DALRecordset> CreateRecordset();

      virtual void EscapeString(String &sInput);

      virtual std::shared_ptr<IMacroExpander> CreateMacroExpander();

   private:

      //DALConnection::ExecutionResult GetErrorType_(hm_MARIADB *pSQL);
      DALConnection::ExecutionResult GetErrorType_(MYSQL* pSQL);

      void UpdatePassword_();
      void RunScriptFile_(const String &sFile) ;
      void RunCommand_(const String &sCommand) ;
      void LoadSupportsTransactions_(const String &database);      
      void SetConnectionCharacterSet_();      

      //hm_MARIADB *dbconn_;
      MYSQL* dbconn_;

      bool is_connected_;
      bool supports_transactions_;

      ColumnPositionCache column_position_cache_;

   };

}
