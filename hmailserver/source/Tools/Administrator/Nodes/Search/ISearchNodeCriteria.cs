// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

using System.Windows.Forms;

namespace hMailServer.Administrator.Nodes
{
   public interface ISearchNodeCriteria
   {
      bool IsMatch(TreeNode node);
   }
}
