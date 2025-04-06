# For build node project

FROM node:22-alpine AS build

WORKDIR /app

COPY package*.json ./
COPY vite.config.ts ./
COPY index.html ./

RUN npm ci

COPY src ./src
COPY public ./public

RUN npm run build

# Nginx

FROM cgr.dev/chainguard/nginx:latest

COPY --from=build /app/dist /usr/share/nginx/html

COPY ./nginx.conf /etc/nginx/nginx.conf

EXPOSE 8080