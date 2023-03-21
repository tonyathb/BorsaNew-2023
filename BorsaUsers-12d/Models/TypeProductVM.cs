using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BorsaUsers_12d.Models
{
    public class TypeProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegisterOn { get; set; }
        public List<SelectListItem> TypeProducts { get; set; }

    }
}
