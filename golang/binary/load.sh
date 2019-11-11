ghz --insecure \
 --proto ./client.proto \
  -n 100 \
  -c 10 \
  -d '{"Id":"0c21e45c-a9a9-4d63-b65b-481bf8f2e96e"}' \
  --call Users.UserService.GetUser \ 
  0.0.0.0:5002