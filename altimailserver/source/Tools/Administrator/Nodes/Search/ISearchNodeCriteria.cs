// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   public interface ISearchNodeCriteria
   {
      bool IsMatch(TreeNode node);
   }
}
