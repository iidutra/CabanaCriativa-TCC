﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Controllers
{
    [Authorize]
    public class ClienteController : MainController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> NovoEndereco(EnderecoViewModel endereco)
        {
            var response = await _clienteService.AdicionarEndereco(endereco);

            if (ResponsePossuiErros(response)) TempData["Erros"] = 
                ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            return RedirectToAction("EnderecoEntrega", "Pedido");
        }

        [HttpPut]
        public async Task<IActionResult> EditarEndereco(EnderecoViewModel endereco)
        {
            var response = await _clienteService.EditarEndereco(endereco);

            if (ResponsePossuiErros(response)) TempData["Erros"] =
                 ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            return RedirectToAction("EnderecoEntrega", "Pedido");
        }

        [HttpGet]
        [Route("meu-perfil/{id}")]
        public async Task<IActionResult> MeuPerfil(Guid id)
        { 
            var cliente = await _clienteService.ObterPerfil(id);

            return View(cliente);
        }
    }
}