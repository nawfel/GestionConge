﻿using Microsoft.AspNetCore.Mvc;

namespace GestionConge.API.Models
{
    public class CustomValidationProblemDetails :ProblemDetails
    {
       public IDictionary<string, string[]> Errors { get; set; }= new Dictionary<string, string[]>();

    }
}
