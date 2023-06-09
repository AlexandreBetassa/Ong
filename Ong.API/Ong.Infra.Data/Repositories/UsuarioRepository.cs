﻿using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ong.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public IBaseData<Usuario> _db;

        public UsuarioRepository(IBaseData<Usuario> db)
        {
            _db = db;
        }

        public async Task<Usuario> CreateAsync(Usuario entity)
        {
            return await _db.CreateAsync(entity);
        }

        public async Task<Usuario> DeleteAsync(Usuario entity)
        {
            return await _db.DeleteAsync(entity);
        }

        public async Task<Usuario> FindUsuarioByCpf(string cpf)
        {
            return await _db.FindByCpf(cpf);
        }

        public async Task<Usuario> FindUsuarioLogin(string username)
        {
            return await _db.FindUsuarioLogin(username);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _db.GetAllAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _db.GetAllUsuariosAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _db.GetByIdAsync(id);
        }

        public async Task<Usuario> UpdateAsync(Usuario entity)
        {
            return await _db.UpdateAsync(entity);
        }
    }
}
