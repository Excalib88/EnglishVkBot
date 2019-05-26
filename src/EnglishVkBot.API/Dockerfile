FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build

WORKDIR /src
COPY ["EnglishVkBot.API.csproj", "."]
RUN dotnet restore "EnglishVkBot.API.csproj"
COPY . .
RUN dotnet build "EnglishVkBot.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EnglishVkBot.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EnglishVkBot.API.dll"]