﻿using APICatalogo_.Context;
using APICatalogo_.Models;
using APICatalogo_.Pagination;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo_.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<PagedList<Produto>> GetProdutos(ProdutoParameters produtosParameters)
        {
            //return Get()
            //    .OrderBy(on => on.Nome)
            //    .Skip((produtosParameters.PageNumber - 1) * produtosParameters.PageSize)
            //    .Take(produtosParameters.PageSize)
            //    .ToList();

            return await PagedList<Produto>.ToPagedList(Get().OrderBy(on => on.Nome),
                produtosParameters.PageNumber,
                produtosParameters.PageSize);
        }
        public async Task<IEnumerable<Produto>> GetProdutosPorPreco()
        {
            return await Get().OrderBy(c => c.Preco).ToListAsync();
        }
    }
}
