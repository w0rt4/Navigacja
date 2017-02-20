using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MojaNawigacja.Models
{
    [MetadataType(typeof(AdresyMetaData))]
    public partial class Adresy
    {

    }

    public class AdresyMetaData
    {
        public object IdTrasy { get; set; }

        [Required]
        [StringLength(50,ErrorMessage = " maksymalna długość adresu wynosi 50 znaków")]
        [DisplayName("Miejsce Wyjazdu")]
        public object MiejsceWyjazdu { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = " maksymalna długość adresu wynosi 50 znaków")]
        [DisplayName("Miejsce Docelowe")]
        public object MiejsceDocelowe { get; set; }

        [DisplayName("Data dodania")]
        public object DataDodania { get; set; }
    }
}