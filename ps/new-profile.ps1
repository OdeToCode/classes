if (test-path $profile) {
    "Profile already created"
}
else{ 
    New-Item -path $profile -type file -force    
}
notepad $profile