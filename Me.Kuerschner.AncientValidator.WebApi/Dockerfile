FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Me.Kuerschner.AncientValidator.WebApi/Me.Kuerschner.AncientValidator.WebApi.csproj", "Me.Kuerschner.AncientValidator.WebApi/"]
RUN dotnet restore "Me.Kuerschner.AncientValidator.WebApi/Me.Kuerschner.AncientValidator.WebApi.csproj"
COPY . .
WORKDIR "/src/Me.Kuerschner.AncientValidator.WebApi"
RUN dotnet build "Me.Kuerschner.AncientValidator.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Me.Kuerschner.AncientValidator.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Me.Kuerschner.AncientValidator.WebApi.dll"]
