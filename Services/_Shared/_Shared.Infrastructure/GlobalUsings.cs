﻿global using _Shared.Domain.Entities;
global using _Shared.Domain.Events.Domain;
global using _Shared.Domain.Extensions;
global using _Shared.Domain.Interfaces;
global using _Shared.Infrastructure.EntityMappings;
global using _Shared.Infrastructure.Enums;
global using _Shared.Infrastructure.Extensions.Mediators;
global using _Shared.Infrastructure.Interfaces;
global using _Shared.Infrastructure.Interfaces.IntegrationEvents;
global using _Shared.Infrastructure.Persistences;
global using _Shared.Infrastructure.Settings;
global using Dapper;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Options;
global using Npgsql;
global using System.ComponentModel;
global using System.Data;
global using System.Text.Json.Serialization;
global using _Shared.Domain.Events.Integration;