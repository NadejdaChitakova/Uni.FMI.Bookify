﻿using Microsoft.AspNetCore.Http;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Core.Models.Models.Response;

namespace Uni_FMI.Bookify.Core.Business.Contracts;

public interface IApartmentService
{
    Task<ApartmentResponse?> GetApartment(Guid id);

    Task<List<ApartmentResponse>> GetApartments(SearchApartmentsRequest request);

    Task Insert(Guid id);

    Task Update(UpdateApartmentRequest request, CancellationToken cancellationToken);

    Task Delete(Guid id);

}