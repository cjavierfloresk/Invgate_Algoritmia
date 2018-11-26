#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 65179
EXPOSE 44372

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["4.Implementacion/4.Implementacion.csproj", "4.Implementacion/"]
RUN dotnet restore "4.Implementacion/4.Implementacion.csproj"
COPY . .
WORKDIR "/src/4.Implementacion"
RUN dotnet build "4.Implementacion.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "4.Implementacion.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "4.Implementacion.dll"]