FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG TARGETARCH

COPY ./src /source

WORKDIR /source
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish ./Desafio.eclipseworks.TaskManager.Api/Desafio.EclipseWorks.TaskManager.Api.csproj -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

ENV \
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    LC_ALL=en_US.UTF-8 \
    LANG=en_US.UTF-8
RUN apk add --no-cache \
    icu-data-full \
    icu-libs

WORKDIR /app

COPY --from=build /app .
USER $APP_UID

ENTRYPOINT ["dotnet", "Desafio.EclipseWorks.TaskManager.Api.dll"]