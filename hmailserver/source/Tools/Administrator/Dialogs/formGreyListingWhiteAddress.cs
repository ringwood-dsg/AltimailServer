// Copyright (c) 2010 Martin Knafve / hMailServer.com.  
// http://www.hmailserver.com

using hMailServer.Shared;
using System.Windows.Forms;

namespace hMailServer.Administrator
{
   public partial class formGreyListingWhiteAddress : Form
   {
      public formGreyListingWhiteAddress()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         Strings.Localize(this);
      }

      public void LoadProperties(hMailServer.GreyListingWhiteAddress whiteAddress)
      {
         textIPAddress.Text = whiteAddress.IPAddress;
         textDescription.Text = whiteAddress.Description;
      }

      public void SaveProperties(hMailServer.GreyListingWhiteAddress whiteAddress)
      {
         whiteAddress.IPAddress = textIPAddress.Text;
         whiteAddress.Description = textDescription.Text;
      }
   }
}