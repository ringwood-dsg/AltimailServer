// Copyright (c) 2010 Martin Knafve / AltimailServer.com.  
// http://www.AltimailServer.com

using AltimailServer.Administrator.Nodes;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   internal interface IMainForm
   {
      void ShowItem(INode node);


      void RefreshCurrentNode(System.Drawing.Color color, string newName);
      void RefreshCurrentNode(string newName);
      void RefreshParentNode();
      bool SelectNode(ISearchNodeCriteria criteria);
      void OnContentChanged();
      INode GetCurrentNode();

      void Repaint();

      Cursor Cursor { set; get; }

   }
}
