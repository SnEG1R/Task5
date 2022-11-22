FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Task5.Web/Task5.Web.csproj", "Task5.Web/"]
COPY ["Task5.Persistence/Task5.Persistence.csproj", "Task5.Persistence/"]
COPY ["Task5.Application/Task5.Application.csproj", "Task5.Application/"]
COPY ["Task5.Domain/Task5.Domain.csproj", "Task5.Domain/"]
RUN dotnet restore "Task5.Web/Task5.Web.csproj"
COPY . .
WORKDIR "/src/Task5.Web"
RUN dotnet build "Task5.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Task5.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "Task5.Web.dll"]
