﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Contactos
{
	[Key]
	public int ContactoId { get; set; }

    public string Contacto { get; set; }
}
