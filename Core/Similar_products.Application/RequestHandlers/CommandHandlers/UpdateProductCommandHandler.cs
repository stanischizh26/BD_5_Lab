﻿using MediatR;
using AutoMapper;
using Similar_products.Domain.Abstractions;
using Similar_products.Application.Requests.Commands;

namespace Similar_products.Application.RequestHandlers.CommandHandlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
	private readonly IProductRepository _repository;
	private readonly IMapper _mapper;

	public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Product.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.Product, entity);

		_repository.Update(entity);
		await _repository.SaveChanges();

		return true;
	}
}
