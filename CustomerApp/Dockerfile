FROM node:18-alpine AS build-env
WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build --prod

FROM nginx:alpine
COPY --from=build-env /app/dist/customer-crud-app /usr/share/nginx/html

EXPOSE 80
