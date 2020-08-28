FROM node:current as build
WORKDIR /workspace
COPY . .
RUN npm ci
RUN npm run build
RUN npm run lint
CMD [ "npm", "start" ]
