document.addEventListener("DOMContentLoaded", function () {
    // Function to toggle password visibility
    function togglePasswordVisibility(passwordFieldId, toggleButtonId, toggleIconId) {
        const passwordField = document.getElementById(passwordFieldId);
        const toggleButton = document.getElementById(toggleButtonId);
        const toggleIcon = document.getElementById(toggleIconId);

        toggleButton.addEventListener("click", function () {
            const type = passwordField.getAttribute("type") === "password" ? "text" : "password";
            passwordField.setAttribute("type", type);

            if (type === "password") {
                toggleIcon.classList.remove("bi-eye");
                toggleIcon.classList.add("bi-eye-slash");
            } else {
                toggleIcon.classList.remove("bi-eye-slash");
                toggleIcon.classList.add("bi-eye");
            }
        });
    }

    // Toggle New Password visibility
    togglePasswordVisibility("NewPassword", "toggleNewPassword", "toggleNewPasswordIcon");

    // Toggle Confirm Password visibility
    togglePasswordVisibility("ConfirmPassword", "toggleConfirmPassword", "toggleConfirmPasswordIcon");
});
