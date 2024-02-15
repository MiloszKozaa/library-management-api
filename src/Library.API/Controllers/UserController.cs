﻿using Library.Application.ApiModels;
using Library.Application.Features.User.Commands;
using Library.Application.Features.User.Queries;
using Library.Application.Services.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;
    private readonly IUserRepository _userRepository;
    public UserController(IMediator mediator, IUserRepository userRepository) 
    {
        _mediator = mediator;
        _userRepository = userRepository;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetUsers.Query(), cancellationToken);

        return Ok(ApiResponse.Success(200, response));
    }

    [HttpGet("GetDetail")]
    public async Task<IActionResult> GetUser(Guid userId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetUser.Query(userId), cancellationToken);

        return Ok(ApiResponse.Success(200, response));
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUser.Command command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(ApiResponse.Success(201, response));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUser.UpdateCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(ApiResponse.Success(201, response));
    }

}
