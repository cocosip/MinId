#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
MAINTAINER virtual<1185513330@qq.com>
LABEL version="1.0" description="MinIdApp"

WORKDIR /app

COPY . .

FROM base AS final
WORKDIR /app
COPY --from=base /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "MinIdApp.HttpApi.Host.dll"]
 