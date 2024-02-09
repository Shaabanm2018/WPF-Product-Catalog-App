using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal class Type
    {
        [Serializable]
        public class ProductToShow
        {
            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("RegularPrice")]
            public string RegularPrice { get; set; }

            [JsonProperty("Options")]
            public string[] Options { get; set; }

            [JsonProperty("Id")]
            public int Id { get; set; }

            [JsonProperty("ImagePath")]
            public string ImagePath { get; set; }
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public class Attribute1
        {
            public int id { get; set; }
            public string name { get; set; }
            public int position { get; set; }
            public bool visible { get; set; }
            public bool variation { get; set; }
            public List<string> options { get; set; }
            public string option { get; set; }
        }

        public class BundledItem
        {
            public int bundled_item_id { get; set; }
            public int product_id { get; set; }
            public int menu_order { get; set; }
            public int quantity_min { get; set; }
            public int quantity_max { get; set; }
            public bool priced_individually { get; set; }
            public bool shipped_individually { get; set; }
            public bool override_title { get; set; }
            public string title { get; set; }
            public bool override_description { get; set; }
            public string description { get; set; }
            public bool optional { get; set; }
            public bool hide_thumbnail { get; set; }
            public string discount { get; set; }
            public bool override_variations { get; set; }
            public List<object> allowed_variations { get; set; }
            public bool override_default_variation_attributes { get; set; }
            public List<object> default_variation_attributes { get; set; }
            public string single_product_visibility { get; set; }
            public string cart_visibility { get; set; }
            public string order_visibility { get; set; }
            public string single_product_price_visibility { get; set; }
            public string cart_price_visibility { get; set; }
            public string order_price_visibility { get; set; }
            public string stock_status { get; set; }
        }

        public class BundleProductDetails
        {
            public bool per_item_pricing { get; set; }
            public List<Product> products { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
        }

        public class Collection
        {
            public string href { get; set; }
        }

        public class Component
        {
            public string name { get; set; }
            public List<Product> products { get; set; }
            public int number_of_different_products_allowed { get; set; }
            public int minimum_quantity { get; set; }
            public int? maximum_quantity { get; set; }
            public bool is_same_sku_free_item { get; set; }
            public int same_sku_free_quantity { get; set; }
            public int different_sku_free_quantity { get; set; }
            public bool lowest_price_free { get; set; }
            public int discount_percentage { get; set; }
            public bool discount_on_regular_price { get; set; }
            public int discount_amount { get; set; }
            public int? price { get; set; }
            public int? composite_minimum_order { get; set; }
            public object? purchase_with_purchase_minimum_order { get; set; } = null;
        }

        public class CompositeComponent
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string query_type { get; set; }
            public List<int> query_ids { get; set; }
            public object default_option_id { get; set; } = null;
            public string thumbnail_id { get; set; }
            public int quantity_min { get; set; }
            public object quantity_max { get; set; } = null;
            public bool priced_individually { get; set; }
            public bool shipped_individually { get; set; }
            public bool optional { get; set; }
            public object discount { get; set; } = null;
            public string options_style { get; set; }
        }

        public class CompositeProductDetails
        {
            public string per_item_pricing { get; set; }
            public List<Component> components { get; set; }
        }

        public class CompoundProductParent
        {
            public int id { get; set; }
            public object customer_tiers { get; set; } = null;
            public object price_tags { get; set; } = null;
        }

        public class CustomFields
        {
            public string to_hide { get; set; }
            public string cost { get; set; }
            public string customer_tiers_on_sale { get; set; }
            public string variation_barcode { get; set; }
            public string variation_shelf { get; set; }
            public string minprice { get; set; }
            public string conversionrategroup { get; set; }
            public string conversionrate { get; set; }
            public string sales_item { get; set; }
            public string internal_sales_item { get; set; }
            public string inventory_item { get; set; }
            public string to_hide_during_picking_and_packing { get; set; }
            public string source { get; set; }
            public string disallow_children_backorders { get; set; }
            public string group { get; set; }
            public string date_valid_from { get; set; }
            public string date_valid_to { get; set; }
            public string internal_description { get; set; }
            public string discontinued { get; set; }
            public string customer_tiers { get; set; }
            public string barcode { get; set; }
            public string is_rack_barcode { get; set; }
            public string customers { get; set; }
            public string price_tags { get; set; }
        }

        public class DefaultAttribute
        {
            public int id { get; set; }
            public string name { get; set; }
            public string option { get; set; }
        }

        public class Dimensions
        {
            public string length { get; set; }
            public string width { get; set; }
            public string height { get; set; }
        }

        public class Image1
        {
            public int id { get; set; }
            public string src { get; set; }
            public string alt { get; set; }
            public object hash { get; set; } = null;
            public string src_small { get; set; }
            public string src_medium { get; set; }
            public string src_large { get; set; }
        }

        public class Inventory
        {
            public int branch_id { get; set; }
            public object batch_id { get; set; } = null;
            public int stock_quantity { get; set; }
            public int physical_stock_quantity { get; set; }
            public string updated_at { get; set; }
        }

        public class Links
        {
            public List<Self> self { get; set; }
            public List<Collection> collection { get; set; }
        }

        public class MixedSkuVolumePricingGroup
        {
            public List<object> product_ids { get; set; } = null;
            public List<object> product_attributes { get; set; } = null;
        }

        public class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public DateTime date_modified { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public string catalog_visibility { get; set; }
            public string description { get; set; }
            public string sku { get; set; }
            public string regular_price { get; set; }
            public string sale_price { get; set; }
            public string date_on_sale_from { get; set; }
            public string date_on_sale_to { get; set; }
            public string tax_class { get; set; }
            public bool manage_stock { get; set; }
            public int stock_quantity { get; set; }
            public bool in_stock { get; set; }
            public string backorders { get; set; }
            public bool backorders_allowed { get; set; }
            public bool backordered { get; set; }
            public string weight { get; set; }
            public Dimensions dimensions { get; set; }
            public string shipping_class { get; set; }
            public int shipping_class_id { get; set; }
            public List<object> cross_sell_ids { get; set; } = null;
            public List<Category> categories { get; set; }
            public List<object> tags { get; set; } = null;
           // public List<Image> images { get; set; }
            public List<Attribute> attributes { get; set; }
            public List<object> default_attributes { get; set; } = null;
            public List<Variation> variations { get; set; }
            public int menu_order { get; set; }
            public string composite_layout { get; set; }
            public List<object> composite_components { get; set; } = null;
            public List<object> composite_scenarios { get; set; } = null;
            public string bundle_layout { get; set; }
            public List<object> bundled_by { get; set; } = null;
            public List<object> bundled_items { get; set; } = null;
            public MixedSkuVolumePricingGroup mixed_sku_volume_pricing_group { get; set; }
            public CustomFields custom_fields { get; set; }
            public List<object> pricing_groups { get; set; } = null;
            public object composite_product_details { get; set; } = null;
            public object bundle_product_details { get; set; } = null;
            public int group_of { get; set; }
            public object minimum_quantity { get; set; } = null;
            public object maximum_quantity { get; set; } = null;
            public string insurance_class { get; set; }
            public object insurance_class_id { get; set; } = null;
            public List<int> allowed_variations { get; set; }
            public List<string> allowed_variation_skus { get; set; }
            public Product product { get; set; }
            public bool optional { get; set; }
            public object price { get; set; } = null;
            public int discount_percentage { get; set; }
        }

        public class Product3
        {
            public int id { get; set; }
            public string name { get; set; }
            public DateTime date_modified { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public string catalog_visibility { get; set; }
            public string description { get; set; }
            public string sku { get; set; }
            public string regular_price { get; set; }
            public string sale_price { get; set; }
            public string date_on_sale_from { get; set; }
            public string date_on_sale_to { get; set; }
            public string tax_class { get; set; }
            public bool manage_stock { get; set; }
            public int stock_quantity { get; set; }
            public bool in_stock { get; set; }
            public string backorders { get; set; }
            public bool backorders_allowed { get; set; }
            public bool backordered { get; set; }
            public string weight { get; set; }
            public Dimensions dimensions { get; set; }
            public string shipping_class { get; set; }
            public int shipping_class_id { get; set; }
            public List<object> cross_sell_ids { get; set; } = null;
            public List<Category> categories { get; set; }
            public List<object> tags { get; set; } = null;
           // public List<Image> images { get; set; }
            public List<Attribute> attributes { get; set; }
            public List<DefaultAttribute> default_attributes { get; set; }
            public List<Variation> variations { get; set; }
            public int menu_order { get; set; }
            public string composite_layout { get; set; }
            public List<object> composite_components { get; set; } = null;
            public List<object> composite_scenarios { get; set; } = null;
            public string bundle_layout { get; set; }
            public List<string> bundled_by { get; set; }
            public List<object> bundled_items { get; set; } = null;
            public MixedSkuVolumePricingGroup mixed_sku_volume_pricing_group { get; set; }
            public CustomFields custom_fields { get; set; }
            public List<object> pricing_groups { get; set; }
            public List<CompoundProductParent> compound_product_parents { get; set; }
            public object composite_product_details { get; set; } = null;
            public object bundle_product_details { get; set; } = null;
            public int group_of { get; set; }
            public object minimum_quantity { get; set; } = null;
            public object maximum_quantity { get; set; } = null;
            public string insurance_class { get; set; }
            public object insurance_class_id { get; set; } = null;
            public List<object> allowed_variations { get; set; } = null;
        }

        public class RootProduct
        {
            public int id { get; set; }
            public string name { get; set; }
            public DateTime date_modified { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public string catalog_visibility { get; set; }
            public string description { get; set; }
            public string sku { get; set; }
            public object regular_price { get; set; } = null;
            public string sale_price { get; set; }
            public string date_on_sale_from { get; set; }
            public string date_on_sale_to { get; set; }
            public string tax_class { get; set; }
            public bool manage_stock { get; set; }
            public int? stock_quantity { get; set; }
            public bool in_stock { get; set; }
            public string backorders { get; set; }
            public bool backorders_allowed { get; set; }
            public bool backordered { get; set; }
            public string weight { get; set; }
            public Dimensions dimensions { get; set; }
            public string shipping_class { get; set; }
            public int shipping_class_id { get; set; }
            public List<object> cross_sell_ids { get; set; } = null;
            public List<Category> categories { get; set; }
            public List<object> tags { get; set; } = null;
            ///public List<image> images { get; set; }
            public List<Attribute> attributes { get; set; }
            public List<object> default_attributes { get; set; } = null;
            public List<Variation> variations { get; set; }
            public int menu_order { get; set; }
            public string composite_layout { get; set; }
            public List<CompositeComponent> composite_components { get; set; }
            public List<object> composite_scenarios { get; set; } = null;
            public string bundle_layout { get; set; }
            public List<object> bundled_by { get; set; } = null;
            public List<BundledItem> bundled_items { get; set; }
            public MixedSkuVolumePricingGroup mixed_sku_volume_pricing_group { get; set; }
            public CustomFields custom_fields { get; set; }
            public List<object> pricing_groups { get; set; } = null;
            public CompositeProductDetails composite_product_details { get; set; }
            public BundleProductDetails bundle_product_details { get; set; }
            public int group_of { get; set; }
            public object minimum_quantity { get; set; } = null;
            public object maximum_quantity { get; set; } = null;
            public string insurance_class { get; set; }
            public object insurance_class_id { get; set; } = null;
            public Links _links { get; set; }
            public string points_earned { get; set; }
            public string points_required { get; set; }
            public string maximum_points_discount { get; set; }
            public List<Inventory> inventory { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Variation
        {
            public int id { get; set; }
            public string sku { get; set; }
            public string description { get; set; }
            public string regular_price { get; set; }
            public string sale_price { get; set; }
            public string date_on_sale_from { get; set; }
            public string date_on_sale_to { get; set; }
            public string tax_class { get; set; }
            public bool manage_stock { get; set; }
            public int stock_quantity { get; set; }
            public bool in_stock { get; set; }
            public string backorders { get; set; }
            public bool backorders_allowed { get; set; }
            public bool backordered { get; set; }
            public string weight { get; set; }
            public Dimensions dimensions { get; set; }
            public string shipping_class { get; set; }
            public int shipping_class_id { get; set; }
            public List<object> image { get; set; } = null;
            public List<Attribute> attributes { get; set; }
            public CustomFields custom_fields { get; set; }
            public string points_earned { get; set; }
            public string points_required { get; set; }
            public string maximum_points_discount { get; set; }
            public string insurance_class { get; set; }
            public object insurance_class_id { get; set; } = null;
            public List<Inventory> inventory { get; set; }
        }


    }
}
