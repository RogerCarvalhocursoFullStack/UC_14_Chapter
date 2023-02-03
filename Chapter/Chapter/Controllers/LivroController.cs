﻿using Chapter.Models;
using Chapter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;
        
        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try 
            {
                return Ok(_livroRepository.Ler());
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
                Livro livro = _livroRepository.BuscarPorId(id);

                if (livro == null) 
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);
                return Ok(livro);   
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Atualizar(int id, Livro livro)
        {
            try 
            {
                _livroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        
        }

    }
}
