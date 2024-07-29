﻿using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObject;
using Shop.Domain.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg
{
    public class Product :AggregateRoot
    {
     

        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }
        private Product()
        {

        }
        public Product(string title, string imageName, string description, long categoryId, long subCategoryId,
            string slug, SeoData seoData, IProductDomainService domainService)
        {
            Guard(title, slug, imageName, description, domainService);

            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void Edit(string title, string imageName, string description, long categoryId, long subCategoryId,
           string slug, SeoData seoData, IProductDomainService domainService)
        {
            Guard(title,slug,imageName, description, domainService );
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }
        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }
        public void RemoveImage(long id)
        {
            var image = Images.FirstOrDefault(f => f.Id == id);
            if (image == null)
                return;
            Images.Remove(image);
        }
        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(s => s.ProductId = Id);
            Specifications = specifications;
        }
        public void Guard(string title, string imageName, string description,string slug , IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (slug != Slug)
                if (domainService.SlugIsExist(slug.ToSlug()))
                    throw new SlugIsDuplicateException();

        }
    } 
}