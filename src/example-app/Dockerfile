    FROM node:14.17.0-alpine as build-step
    RUN mkdir -p /app
    WORKDIR /app
    COPY src/example-app/package.json /app
    RUN npm install
    COPY src/example-app/. /app
    RUN npm run build --prod

    FROM nginx:1.20.1
    COPY --from=build-step app/dist/example-app /usr/share/nginx/html
    EXPOSE 4200:80