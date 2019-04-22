FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["template.API/template.API.csproj", "template.API/"]
RUN dotnet restore "template.API/template.API.csproj"
COPY . .
WORKDIR "/src/template.API"
RUN dotnet build "template.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "template.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "template.API.dll"]
