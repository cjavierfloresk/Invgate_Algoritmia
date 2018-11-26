FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 65150
EXPOSE 44398

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Implementacion/Implementacion.csproj", "Implementacion/"]
RUN dotnet restore "Implementacion/Implementacion.csproj"
COPY . .
WORKDIR "/src/Implementacion"
RUN dotnet build "Implementacion.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Implementacion.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Implementacion.dll"]