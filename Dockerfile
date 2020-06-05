# builder ---------------------------------------------------------------------

FROM microsoft/dotnet:2.2-sdk-alpine AS builder

WORKDIR /app

COPY *.sln ./

COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

COPY test/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p test/ && mv $file test/; done

RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o ../../out

RUN echo "{"\"container_creation_date"\" : "\"$(date --utc +%FT%TZ)"\"}" > imprint.json

# runtime ---------------------------------------------------------------------

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime

ENV DOTNET_USE_POLLING_FILE_WATCHER=false
ENV ASPNETCORE_ENVIRONMENT=Production

# Change timezone to local time
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

WORKDIR /app
COPY --from=builder /app/out ./
COPY --from=builder /app/imprint.json /var/quality-service/imprint.json


ENTRYPOINT ["dotnet", "EnqueteApi.dll"]
