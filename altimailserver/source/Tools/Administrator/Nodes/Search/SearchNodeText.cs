// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   public class SearchNodeText : ISearchNodeCriteria
   {
      private string _title;

      public SearchNodeText(string title)
      {
         _title = title;
      }

      public bool IsMatch(TreeNode node)
      {
         if (node.Text == _title)
            return true;
         else
            return false;
      }


   }
}
