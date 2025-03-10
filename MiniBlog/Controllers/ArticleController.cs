﻿namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Service;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private IArticleService articleService;
        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public ActionResult<List<Article>> List()
        {
            return Ok(articleService.List());
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {

            return Created("/article", articleService.Create(article));
        }

        [HttpGet("{id}")]
        public ActionResult<Article> GetById(Guid id)
        {
            return articleService.GetById(id);
        }
    }
}