// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   public interface ISearchNodeCriteria
   {
      bool IsMatch(TreeNode node);
   }
}
