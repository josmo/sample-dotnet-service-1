FROM microsoft/dotnet:runtime
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY ./out/NancyService.dll /usr/src/app
CMD [ "dotnet",  "./NancyService.dll" ]