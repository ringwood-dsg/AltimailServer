// Juan Davel/ringwood-dsg, 2025/06/08
// https://altimailserver.org

namespace Shared.Models
{
   public sealed class ComboBoxDataItem
   {
      public ComboBoxDataItem()
      {
          
      }

      public ComboBoxDataItem(string name = "", object value = null)
      {
         Name = name;
         Value = value;
      }

      public string Name { get; set; } 
      public object Value { get; set; }
   }
}