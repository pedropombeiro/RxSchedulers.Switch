while ($true)
{
	git.exe fetch --all
	
	Write-Host "Waiting 30 seconds..."
	
	sleep 30
}