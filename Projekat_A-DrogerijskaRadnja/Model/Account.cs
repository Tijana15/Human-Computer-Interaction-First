using System;
using System.ComponentModel.DataAnnotations;

namespace Projekat_A_DrogerijskaRadnja.Model
{
    public class Account
    {
         public int IdNaloga { get; set; }
         public string KorisnickoIme { get; set; }
         public string Lozinka { get; set; }
    }
}
