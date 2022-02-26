using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfase;

namespace CodeTo.Core.ViewModel.PermiossionViewModel
{
    
        public class PermissionIndexViewModel : IIndexVeiwModel<byte>
        {
            public byte Id { get; set; }
            public string Title { get; set; }

        }

        public class PermissionCreateorEditeViewModel : ICreateOrEditeViewModel<byte>
        {
            [Key]
            public byte Id { get; set; }

            [Display(Name = "شرح")]
            [Required(ErrorMessage = "وارد کرد نام الزامیست")]
            [MaxLength(100)]
            public string Title { get; set; }
            public DateTime CreateDate { get; set; }
        }
    
}
