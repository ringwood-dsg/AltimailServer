// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using System;
using System.Windows.Forms;

namespace AltimailServer.Administrator.Nodes
{
   public class SearchNodeType : ISearchNodeCriteria
   {
      private Type _type;

      public SearchNodeType(Type type)
      {
         _type = type;
      }

      public bool IsMatch(TreeNode node)
      {
         INode internalNode = node.Tag as INode;

         if (internalNode.GetType() == _type)
            return true;
         else
            return false;
      }


   }
}
