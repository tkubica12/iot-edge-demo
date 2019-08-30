# Install components
curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list > ./microsoft-prod.list
sudo cp ./microsoft-prod.list /etc/apt/sources.list.d/
curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
sudo cp ./microsoft.gpg /etc/apt/trusted.gpg.d/
sudo apt-get update
sudo apt-get install moby-engine moby-cli -y
sudo apt-get install iotedge -y
sudo usermod -aG docker $USER

# Configure
sudo nano /etc/iotedge/config.yaml

# Restart service and check status
sudo systemctl restart iotedge
sudo systemctl status iotedge