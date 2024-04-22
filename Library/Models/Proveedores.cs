﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Proveedores
{
	[Key]
	public int ProveedorId { get; set; }

	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime FechaCreacion { get; set; } = DateTime.Today;

	[Required(ErrorMessage = "Debe ingresar el nombre de la empresa.")]
	[StringLength(32, ErrorMessage = "El límite es de 32 caracteres.")]
	public string Empresa { get; set; }

	[Required(ErrorMessage = "Debe ingresar el nombre del representante de la empresa.")]
	[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Este campo no acepta números ni caracteres especiales.")]
	[StringLength(25, ErrorMessage = "El límite es de 32 caracteres.")]
	public string Representante { get; set; }

	public string CedulaRepresentante { get; set; }

	[Required(ErrorMessage = "Debe ingresar la dirección de la empresa")]
	[StringLength(50, ErrorMessage = "El límite es de 50 caracteres.")]
	public string Direccion { get; set; }

	[Required(ErrorMessage = "Debe ingresar un email")]
	[EmailAddress(ErrorMessage = "El formato para el email no es válido.")]
	[RegularExpression(@"^[^\s]+@[^\s]+\.[^\s]+$", ErrorMessage = "El email no puede contener espacios.")]
	[StringLength(40, ErrorMessage = "El límite es de 40 caracteres.")]
	public string Email { get; set; }

	[Required(ErrorMessage = "Debe ingresar un número de cuenta bancaria")]
	[RegularExpression(@"^[0-9]{8,20}$", ErrorMessage = "El número de cuenta bancaria debe tener entre 8 y 20 dígitos númericos")]
	public string NumeroCuenta { get; set; }

	[Required(ErrorMessage = "Debe ingresar el nombre del banco")]
	[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El campo Banco solo puede contener letras y espacios.")]
	[StringLength(25, ErrorMessage = "El límite es de 25 caracteres.")]
	public string Banco { get; set; }

	[ForeignKey("TiposContribuyente")]
	[Range(1, int.MaxValue, ErrorMessage = "Debe elegir un tipo de contribuyente.")]
	public int TipoContribuyenteId { get; set; }

	[Required(ErrorMessage = "Debe ingresar un número de RNC")]
	[RegularExpression(@"^\d{3}\d{7}\d{1}$", ErrorMessage = "El RNC debe tener 11 dígitos numéricos")]
	public string RNC { get; set; }

	[StringLength(250, ErrorMessage = "El límite es de 250 caracteres.")]
	public string Nota { get; set; } = string.Empty;

	public bool Eliminado { get; set; } = false;

	[ForeignKey("ProveedorId")]
	public ICollection<ProveedoresDetalle> ProveedorDetalle { get; set; } = new List<ProveedoresDetalle>();
}
