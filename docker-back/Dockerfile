FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /financeiro


COPY Financeiro.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /financeiro
COPY --from=build-env /financeiro/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "SuaApp.dll"]