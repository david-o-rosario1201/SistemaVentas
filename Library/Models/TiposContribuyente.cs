﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class TiposContribuyente
{
	[Key]
	public int TipoContribuyenteId { get; set; }

    public string TipoContribuyente { get; set; }
}
