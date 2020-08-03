﻿using DAN_XLVIII_Kristina_Garcia_Francisco.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DAN_XLVIII_Kristina_Garcia_Francisco
{
    /// <summary>
    /// Class that includes all CRUD functions of the application
    /// </summary>
    class Service
    {
        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    List<tblUser> list = new List<tblUser>();
                    list = (from x in context.tblUsers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about items
        /// </summary>
        /// <returns>a list of found items</returns>
        public List<tblItem> GetAllItems()
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    List<tblItem> list = new List<tblItem>();
                    list = (from x in context.tblItems select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about shopping carts from the user
        /// </summary>
        /// <returns>a list of found shopping carts</returns>
        public List<tblShoppingCart> GetAllUserShoppingCarts(int UserID)
        {
            try
            {
                List<tblShoppingCart> list = new List<tblShoppingCart>();
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    for (int i = 0; i < GetAllShoppingCarts().Count; i++)
                    {
                        if (GetAllShoppingCarts()[i].UserID == UserID)
                        {
                            list.Add(GetAllShoppingCarts()[i]);

                        }
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        /// <summary>
        /// Gets all information about all shopping carts
        /// </summary>
        /// <returns>a list of found shopping cart</returns>
        public List<tblShoppingCart> GetAllShoppingCarts()
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    List<tblShoppingCart> list = new List<tblShoppingCart>();
                    list = (from x in context.tblShoppingCarts select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about orders from the user
        /// </summary>
        /// <returns>a list of found orders</returns>
        public List<tblOrder> GetAllUserOrders(int UserID)
        {
            try
            {
                List<tblOrder> list = new List<tblOrder>();
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    for (int i = 0; i < GetAllOrders().Count; i++)
                    {
                        if (GetAllOrders()[i].UserID == UserID)
                        {
                            list.Add(GetAllOrders()[i]);

                        }
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        /// <summary>
        /// Gets all information about all orders
        /// </summary>
        /// <returns>a list of found orders</returns>
        public List<tblOrder> GetAllOrders()
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    List<tblOrder> list = new List<tblOrder>();
                    list = (from x in context.tblOrders select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about all pending orders
        /// </summary>
        /// <returns>a list of found orders</returns>
        public List<tblOrder> GetAllPendingOrders()
        {
            try
            {
                List<tblOrder> list = new List<tblOrder>();
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    for (int i = 0; i < GetAllOrders().Count; i++)
                    {
                        if (GetAllOrders()[i].OrderStatus == "Waiting")
                        {
                            list.Add(GetAllOrders()[i]);

                        }
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about all non pending orders
        /// </summary>
        /// <returns>a list of found orders</returns>
        public List<tblOrder> GetAllNonPendingOrders()
        {
            try
            {
                List<tblOrder> list = new List<tblOrder>();
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    for (int i = 0; i < GetAllOrders().Count; i++)
                    {
                        if (GetAllOrders()[i].OrderStatus != "Waiting")
                        {
                            list.Add(GetAllOrders()[i]);

                        }
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Searches for a user with the given jmbg, returns 0 if it does not exist
        /// </summary>
        /// <param name="jmbg">Checks if the user with that JMBG exists</param>
        /// <returns>The found user id</returns>
        public int FindUserByJMBG(string jmbg)
        {
            for (int i = 0; i < GetAllUsers().Count; i++)
            {
                if (GetAllUsers()[i].JMBG == jmbg)
                {
                    return GetAllUsers()[i].UserID;
                }
            }
            return 0;
        }

        /// <summary>
        /// Checks if the shopping cart exists
        /// </summary>
        /// <param name="itemID">Id of the item in the cart</param>
        /// <param name="userID">Id of the user that owns the cart</param>
        /// <returns>the shoppingcart id</returns>
        public int CartExists(int itemID, int userID)
        {
            int cartId = 0;

            if (GetAllUserShoppingCarts(userID).Any())
            {
                for (int i = 0; i < GetAllUserShoppingCarts(userID).Count; i++)
                {
                    if (GetAllUserShoppingCarts(userID)[i].ItemID == itemID)
                    {
                        cartId = GetAllUserShoppingCarts(userID)[i].ShoppingCartID;
                    }
                }
            }

            return cartId;
        }

        /// <summary>
        /// Checks the amount of items in the cart
        /// </summary>
        /// <param name="cartID">The cart id</param>
        /// <returns>the total amount of items in the cart</returns>
        public int CurrentCartItemAmount(int cartID)
        {
            int currentAmount = 0;

            for (int i = 0; i < GetAllShoppingCarts().Count; i++)
            {
                if (GetAllShoppingCarts()[i].ShoppingCartID == cartID)
                {
                    currentAmount = (int)GetAllShoppingCarts()[i].Amount;
                }
            }

            return currentAmount;
        }

        /// <summary>
        /// Adds the item if the itemID exists
        /// </summary>
        /// <param name="userID">the item that is being added for the user</param>
        /// <param name="item">the item that is being added</param> 
        /// <returns>a new shopping cart element</returns>
        public tblShoppingCart AddItem(tblItem item, int userID)
        {
            int cartId = CartExists(item.ItemID, userID);

            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    if (cartId == 0)
                    {
                        tblShoppingCart newShoppingCart = new tblShoppingCart
                        {
                            Amount = item.Amount,
                            UserID = userID,
                            ItemID = item.ItemID
                        };

                        context.tblShoppingCarts.Add(newShoppingCart);
                        context.SaveChanges();

                        return newShoppingCart;
                    }
                    else
                    {
                        tblShoppingCart shoppingCartToEdit = (from ss in context.tblShoppingCarts where ss.ShoppingCartID == cartId select ss).First();

                        shoppingCartToEdit.Amount = item.Amount;
                        shoppingCartToEdit.UserID = shoppingCartToEdit.UserID;
                        shoppingCartToEdit.ItemID = shoppingCartToEdit.ItemID;

                        shoppingCartToEdit.ShoppingCartID = cartId;
                        context.SaveChanges();
                       
                        return shoppingCartToEdit;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Adds the user
        /// </summary>
        /// <param name="user">the user that is being added</param> 
        /// <returns>a new user</returns>
        public tblUser AddUser(tblUser user)
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    if (FindUserByJMBG(user.JMBG) == 0)
                    {
                        tblUser newUser = new tblUser
                        {
                            JMBG = user.JMBG
                        };

                        context.tblUsers.Add(newUser);
                        context.SaveChanges();
                        user.UserID = newUser.UserID;

                        return newUser;
                    }
                    else
                    {
                        user.UserID = FindUserByJMBG(user.JMBG);
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Empries the shopping cart of the user
        /// </summary>
        /// <param name="userID">users whoes shopping cart we are empting</param>
        public void EmptyShoppingCart(int userID)
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    for (int i = 0; i < GetAllUserShoppingCarts(userID).Count; i++)
                    {
                        tblShoppingCart shoppingCartToRemove = (from r in context.tblShoppingCarts
                                                                where r.UserID == userID
                                                                select r).First();

                        context.tblShoppingCarts.Remove(shoppingCartToRemove);
                        context.SaveChanges();
                    }                   
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Adds the order if the userID exists
        /// </summary>
        /// <param name="userID">oreder for the specific user</param>
        /// <returns>a new order</returns>
        public tblOrder AddOrder(int userID)
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    tblOrder newOrder = new tblOrder
                    {
                        TotalPrice = TotalValue(),
                        OrderStatus = "Waiting",
                        OrderCreated = DateTime.Now,
                        UserID = userID
                    };

                    context.tblOrders.Add(newOrder);
                    EmptyShoppingCart(userID);

                    context.SaveChanges();

                    return newOrder;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Accepts the order if the order exists
        /// </summary>
        /// <param name="order">accepts for the specific order</param>
        public void AcceptOrder(tblOrder order)
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    tblOrder orderToEdit = (from ss in context.tblOrders where ss.OrderID == order.OrderID select ss).First();

                    orderToEdit.TotalPrice = order.TotalPrice;
                    orderToEdit.OrderStatus = "Accepted";
                    orderToEdit.OrderCreated = order.OrderCreated;

                    orderToEdit.OrderID = order.OrderID;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Denies the order if the order exists
        /// </summary>
        /// <param name="order">denies for the specific order</param>
        public void DenyOrder(tblOrder order)
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    tblOrder orderToEdit = (from ss in context.tblOrders where ss.OrderID == order.OrderID select ss).First();

                    orderToEdit.TotalPrice = order.TotalPrice;
                    orderToEdit.OrderStatus = "Denied";
                    orderToEdit.OrderCreated = order.OrderCreated;

                    orderToEdit.OrderID = order.OrderID;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Deletes item from shopping chart
        /// </summary>
        /// <param name="item">the item that is being deleted</param>
        /// <param name="userID">the user that has the item</param>
        public void RemoveItem(tblItem item, int userID)
        {
            int cartId = CartExists(item.ItemID, userID);

            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    tblShoppingCart shoppingCartToRemove = (from r in context.tblShoppingCarts where r.ShoppingCartID == cartId select r).First();

                    context.tblShoppingCarts.Remove(shoppingCartToRemove);                    
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Deletes the order
        /// </summary>
        /// <param name="order">the order that is being deleted</param>
        public void DeleteOrder(tblOrder order)
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    tblOrder orderToRemove = (from r in context.tblOrders where r.OrderID == order.OrderID select r).First();

                    context.tblOrders.Remove(orderToRemove);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Calculates the total value of items in the cart
        /// </summary>
        /// <returns>The total value</returns>
        public string TotalValue()
        {
            Service service = new Service();

            double orderPrice = 0;

            for (int i = 0; i < service.GetAllUserShoppingCarts(LoggedUser.CurrentUser.UserID).Count; i++)
            {
                int index = service.GetAllItems().FindIndex(f => f.ItemID == service.GetAllUserShoppingCarts(LoggedUser.CurrentUser.UserID)[i].ItemID);
                double price = double.Parse(service.GetAllItems()[index].Price);
                orderPrice = orderPrice + (double)service.GetAllUserShoppingCarts(LoggedUser.CurrentUser.UserID)[i].Amount * price;
            }
            return orderPrice.ToString();
        }
    }
}
