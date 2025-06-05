using AltimailServer.Shared;
using System.Windows.Forms;


namespace AltimailServer.Administrator
{
   public partial class formWhiteListAddress : Form
   {
      public formWhiteListAddress()
      {
         InitializeComponent();

         new TabOrderManager(this).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
         Strings.Localize(this);
      }

      public void SaveProperties(AltimailServer.WhiteListAddress address)
      {
         address.LowerIPAddress = textLowerIP.Text;
         address.UpperIPAddress = textUpperIP.Text;
         address.Description = textDescription.Text;
         address.EmailAddress = textEmailAddress.Text;
      }

      public void LoadProperties(AltimailServer.WhiteListAddress address)
      {
         textLowerIP.Text = address.LowerIPAddress;
         textUpperIP.Text = address.UpperIPAddress;
         textDescription.Text = address.Description;
         textEmailAddress.Text = address.EmailAddress;
      }
   }
}