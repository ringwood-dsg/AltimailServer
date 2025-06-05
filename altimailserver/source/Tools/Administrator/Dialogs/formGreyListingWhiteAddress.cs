// Copyright (c) 2010 Martin Knafve / hmailserver.com.  
// http://www.hmailserver.com

using AltimailServer.Shared;
using System.Windows.Forms;

namespace AltimailServer.Administrator
{
   public partial class formGreyListingWhiteAddress : Form
   {
      public formGreyListingWhiteAddress()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         Strings.Localize(this);
      }

      public void LoadProperties(AltimailServer.GreyListingWhiteAddress whiteAddress)
      {
         textIPAddress.Text = whiteAddress.IPAddress;
         textDescription.Text = whiteAddress.Description;
      }

      public void SaveProperties(AltimailServer.GreyListingWhiteAddress whiteAddress)
      {
         whiteAddress.IPAddress = textIPAddress.Text;
         whiteAddress.Description = textDescription.Text;
      }
   }
}