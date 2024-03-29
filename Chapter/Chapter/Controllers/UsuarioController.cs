﻿using Chapter.Interfaces;
using Chapter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public UsuarioController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        [HttpGet]

        public IActionResult Listar()
        {
            try 
            {
                return Ok(_iUsuarioRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.BurcarPorId(id);

                if (usuarioBuscado == null) 
                {
                    return NotFound();
                }
                   return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]

        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Cadastrar(usuario);
                return StatusCode(201);    
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Atualizar(id, usuario);
                return Ok("Usuario Atualizado! :)");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _iUsuarioRepository.Deletar(id);
                return Ok("Usuário Deletado! :)");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
