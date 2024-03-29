﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added successfully";
        public static string CarNameInvalid = "The car name must be at least two characters.";
        public static string CarDailyPriceInvalid = "The daily price of the car must be at least zero.";
        public static string CarDeleted = "Car deleted successfully";
        public static string CarUpdated = "Car updated successfully";
        public static string CarsListed = "Cars listed successfully";
        public static string CarDetailsListed = "Car details listed successfully";

        public static string BrandAdded = "Brand added successfully";
        public static string BrandDeleted = "Brand deleted successfully";
        public static string BrandUpdated = "Brand updated successfully";
        public static string BrandsListed = "Brands listed successfully";

        public static string ColorAdded = "Color added successfully";
        public static string ColorDeleted = "Color deleted successfully";
        public static string ColorUpdated = "Color updated successfully";
        public static string ColorsListed = "Colors listed successfully";
        public static string MaintenanceTime = "System is in maintenance";

        public static string UserAdded = "User added successfully";
        public static string UserDeleted = "User deleted successfully";
        public static string UserUpdated = "User updated successfully";
        public static string UsersListed = "Users listed successfully";
        
        public static string CustomerAdded = "Customer added successfully";
        public static string CustomerDeleted = "Customer deleted successfully";
        public static string CustomerUpdated = "Customer updated successfully";
        public static string CustomersListed = "Customers listed successfully";
        
        public static string RentalAdded = "Rental added successfully";
        public static string RentalDeleted = "Rental deleted successfully";
        public static string RentalUpdated = "Rental updated successfully";
        public static string RentalsListed = "Rentals listed successfully";

        public static string CarImageLimitExceeded = "A car can have up to 5 images.";
        public static string CarImageAdded = "Car image added successfully";
        public static string CarImageDeleted = "Car image deleted successfully";
        public static string CarImageUpdated = "Car image updated successfully";
        public static string CarImagesListed = "Car images listed successfully";
        public static string CarImageDoesntExists = "Car image does not exists";

        public static string AuthorizationDenied = "Authorization denied";
        public static string UserRegistered = "User registered successfully";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password error";
        public static string SuccessfulLogin = "Login successfully";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Access token created successfully";
    }
}
