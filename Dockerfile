FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["templateAPI.API/templateAPI.API.csproj", "templateAPI.API/"]
RUN dotnet restore "templateAPI.API/templateAPI.API.csproj"
COPY . .
WORKDIR "/src/templateAPI.API"
RUN dotnet build "templateAPI.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "templateAPI.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "templateAPI.API.dll"]
