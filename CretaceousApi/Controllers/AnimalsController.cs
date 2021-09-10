﻿using CretaceousApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CretaceousApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private CretaceousApiContext _db;

        public AnimalsController(CretaceousApiContext db)
        {
            _db = db;
        }

        private bool AnimalExists(int id)
        {
            return _db.Animals.Any(e => e.AnimalId == id);
        }

        // GET api/animals
        [HttpGet]
        public async Task<List<Animal>> Get()
        {
            return await _db.Animals.ToListAsync();
        }

        // POST api/animals
        [HttpPost]
        public async Task<ActionResult> Post(Animal animal)
        {
            _db.Animals.Add(animal);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
        }

        // GET api/animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            Animal animal = await _db.Animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }
    }
}