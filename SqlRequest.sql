select product.name, category.name from product
                                            left join product_category on product.id = product_category.product_id
                                            left join category on product_category.category_id = category.id;