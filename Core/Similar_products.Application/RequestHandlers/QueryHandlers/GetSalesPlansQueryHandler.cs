﻿using MediatR;
using AutoMapper;
using Similar_products.Application.Dtos;
using Similar_products.Domain.Abstractions;
using Similar_products.Application.Requests.Queries;

namespace Similar_products.Application.RequestHandlers.QueryHandlers;

public class GetSalesPlansQueryHandler : IRequestHandler<GetSalesPlansQuery, IEnumerable<SalesPlanDto>>
{
	private readonly ISalesPlanRepository _repository;
	private readonly IMapper _mapper;

	public GetSalesPlansQueryHandler(ISalesPlanRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<SalesPlanDto>> Handle(GetSalesPlansQuery request, CancellationToken cancellationToken) => 
		_mapper.Map<IEnumerable<SalesPlanDto>>(await _repository.Get(trackChanges: false));
}